# Utiliza la imagen oficial de .NET 8 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

RUN dotnet tool install -g dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
# Copia los archivos de proyecto y restaura dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto del código
COPY . ./

# Exponer el puerto de la aplicación
EXPOSE 5000

# Ejecutar la aplicación
CMD ["dotnet", "run", "--urls", "http://0.0.0.0:5000"]
