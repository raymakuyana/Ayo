#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Ayo.ConveterApp.Api/Ayo.ConveterApp.Api.csproj", "Ayo.ConveterApp.Api/"]
RUN dotnet restore "Ayo.ConveterApp.Api/Ayo.ConveterApp.Api.csproj"
COPY . .
WORKDIR "/src/Ayo.ConveterApp.Api"
RUN dotnet build "Ayo.ConveterApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ayo.ConveterApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ayo.ConveterApp.Api.dll"]