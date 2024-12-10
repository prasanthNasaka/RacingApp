# Use the official .NET 8.0 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["infinitemoto/infinitemoto.csproj", "infinitemoto/"]
RUN dotnet restore "infinitemoto/infinitemoto.csproj"

# Copy the entire application and build it
COPY . .
WORKDIR "/src/infinitemoto"
RUN dotnet build "infinitemoto.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "infinitemoto.csproj" -c Release -o /app/publish

# Use the ASP.NET 8.0 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "infinitemoto.dll"]
