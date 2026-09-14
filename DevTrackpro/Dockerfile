# Stage 1: Runtime base image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# Stage 2: Build stage using .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["DevTrackpro.csproj", "./"]
RUN dotnet restore "DevTrackpro.csproj"
COPY . .
RUN dotnet build "DevTrackpro.csproj" -c Release -o /app/build

# Stage 3: Publish output
FROM build AS publish
RUN dotnet publish "DevTrackpro.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Final runner stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevTrackpro.dll"]