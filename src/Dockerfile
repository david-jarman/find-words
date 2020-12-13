FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ARG PORT=5000
WORKDIR /app
EXPOSE $PORT
ENV ASPNETCORE_URLS=https://*:$PORT

FROM curlimages/curl:latest AS deps
WORKDIR /deps
RUN curl -o words.txt https://raw.githubusercontent.com/dwyl/english-words/7cb484da5de560c11109c8f3925565966015e5a9/words_alpha.txt

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY SpellingBee.csproj .
RUN dotnet restore SpellingBee.csproj
COPY . .
RUN dotnet build SpellingBee.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish SpellingBee.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=deps /deps/words.txt .
ENTRYPOINT ["dotnet", "SpellingBee.dll"]