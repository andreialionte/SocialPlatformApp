# Start with the base ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage: Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY ["SocialPlatformApp/SocialPlatformApp.csproj", "SocialPlatformApp/"]
COPY ["SocialPlatformApp.Business/SocialPlatformApp.Business.csproj", "SocialPlatformApp.Business/"]
COPY ["SocialPlatformApp.Common/SocialPlatformApp.Common.csproj", "SocialPlatformApp.Common/"]
COPY ["SocialPlatformApp.Models/SocialPlatformApp.Models.csproj", "SocialPlatformApp.Models/"]
COPY ["SocialPlatformApp.Repos/SocialPlatformApp.Repos.csproj", "SocialPlatformApp.Repos/"]
COPY ["SocialPlatformApp.sln", "./"]

# Restore the dependencies for all projects
RUN dotnet restore "SocialPlatformApp/SocialPlatformApp.csproj"

# Copy the entire project and build
COPY . .
WORKDIR "/src/SocialPlatformApp"
RUN dotnet build "SocialPlatformApp.csproj" -c Release -o /app/build

# Publish stage: Prepare for deployment
FROM build AS publish
RUN dotnet publish "SocialPlatformApp.csproj" -c Release -o /app/publish

# Final stage: Create a smaller runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SocialPlatformApp.dll"]
