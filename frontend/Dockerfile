# Utiliza la imagen de Node.js
FROM node:18

WORKDIR /app
RUN npm install -g @angular/cli@16
# Copia los archivos de dependencias y las instala
COPY package*.json ./
RUN npm install

# Copia el resto del código
COPY . ./

# Exponer el puerto de la aplicación
EXPOSE 4200

# Ejecutar la aplicación
CMD ["npm", "start"]
