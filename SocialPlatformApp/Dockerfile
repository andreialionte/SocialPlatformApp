
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src


COPY ["SocialPlatformApp/SocialPlatformApp.csproj", "SocialPlatformApp/"]
COPY ["SocialPlatformApp.Business/SocialPlatformApp.Business.csproj", "SocialPlatformApp.Business/"]
COPY ["SocialPlatformApp.Repos/SocialPlatformApp.Repos.csproj", "SocialPlatformApp.Repos/"]
COPY ["SocialPlatformApp.Models/SocialPlatformApp.Models.csproj", "SocialPlatformApp.Models/"]
RUN dotnet restore "./SocialPlatformApp/SocialPlatformApp.csproj"

# Copy the entire project and build
COPY . .
WORKDIR "/src/SocialPlatformApp"
RUN dotnet build "SocialPlatformApp.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "SocialPlatformApp.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SocialPlatformApp.dll"]
