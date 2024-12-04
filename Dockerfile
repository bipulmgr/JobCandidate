FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080

RUN apk add icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

COPY ["src/JobCandidate.Api/JobCandidate.Api.csproj", "src/JobCandidate.Api/"]
COPY ["src/JobCandidate.Core/JobCandidate.Core.csproj", "src/JobCandidate.Core/"]
COPY ["src/JobCandidate.Infrastructure/JobCandidate.Infrastructure.csproj", "src/JobCandidate.Infrastructure/"]
COPY ["src/JobCandidate.Shared/JobCandidate.Shared.csproj", "src/JobCandidate.Shared/"]

COPY ["Directory.Build.props", "Directory.Build.props"]
COPY ["Directory.Packages.props", "Directory.Packages.props"]
COPY ["global.json", "global.json"]
RUN dotnet restore "src/JobCandidate.Api/JobCandidate.Api.csproj"
COPY . .

WORKDIR "/src/src/JobCandidate.Api"

FROM build AS publish
RUN dotnet publish "JobCandidate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobCandidate.Api.dll"] 