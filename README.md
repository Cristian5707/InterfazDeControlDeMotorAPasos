# Proyecto de interfaces - Control de un motor a pasos con ayuda de un arduino

Este proyecto es una aplicacion de escritorio hecha en .net Framework en c# con el 
objetivo de hacer una interfaz grafica funcional para el control de direccion,
velocidad y el inicio o paro de su fucionamiento

---

### Tecnologías

* **Windos .NetFramework**
* **C#**
* **Arduino IDE**
* **Arduino Uno**
* **Motor NEMA17**
* **Driver A4988**

---

### Características Principales
**Control Maestro:** La interfaz cuenta con un control maestro para el encendido, 
apagado y paro de emergencia del motor
**Control de dirección:** Se podria controlar la direccion de giro del motor a pasos
con ayuda de los botones que estaban como flechas
**Control de acceso** Tiene un sistema de seguridad basico de una contraseña y usuarios
definidos por el programador
**Control de velocidad** Puedes controlar las rpm a las que gira el motor.

---

### Instalación
####  Archivo ejecutable
Dirijete a la carpeta de "INTERFACES" y luego a "ELECKIT" y ejecuta el archivo .sln
#### Ejecucion desde Visual Studio 
abre Visual Studio 2022
selecciona abrir una carpeta
seleccione la carpeta de INTERFACES


---

### Uso

1.  Conecte su arduino al puerto que desee
2.  Cargue el codigo y vea cual puerto es
3.  Actualize el puerto correspondiente en el codigo de c#
4.  Conecte correctamente el dirver y el motor con la alimentacion correcta
5.  Ejecute el programa
6.  Inicie sesion (usuario: Cristian), (password:22300198)
7.  Precione un boton de direccion
8.  Seleccione una velocidad
9.  Presione el boton de arranque
10.  Cuando quiera parar, seleccione el boton de parar
11.  Solo presione el boton de paro de emergencia en caso de una


---

### Contribuciones

Aunque este es un proyecto personal, si encuentras un error o tienes una sugerencia para mejorarlo como plantilla, ¡las contribuciones son bienvenidas! Por favor, sigue estos pasos:

1.  **Haz un *fork*** del repositorio.
2.  **Clona tu *fork*** a tu máquina local:
    ```bash
    git clone [https://github.com/TU_USUARIO/TU_REPOSITORIO.git](https://github.com/TU_USUARIO/TU_REPOSITORIO.git)
    ```
3.  **Crea una nueva rama** para tus cambios:
    ```bash
    git checkout -b feature/nombre-de-tu-mejora
    ```
4.  **Realiza tus cambios y haz *commit***:
    ```bash
    git add .
    git commit -m "Agrega una nueva característica o corrige un error"
    ```
5.  **Envía los cambios** a tu *fork* en GitHub:
    ```bash
    git push origin feature/nombre-de-tu-mejora
    ```
6.  **Abre un *pull request*** hacia la rama `main` del repositorio original, explicando tus cambios.

---

### Licencia

Este proyecto está bajo la Licencia **MIT**.
