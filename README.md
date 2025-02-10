# ASP.NET Core Web API Project

This project is built using **ASP.NET Core Web API** with **Repository Design Pattern** and **In-Memory Caching** to enhance performance.

## 📌 Technologies Used

- **ASP.NET Core Web API**
- **Repository Design Pattern**
- **In-Memory Caching**
- **Entity Framework Core** 
- **N Layer Architecture**
- **Clean Architecture**

## 📂 Project Structure

```
📦 Solution
├── 📂 Api        
├── 📂 Caching           
├── 📂 CoreLayer      
├── 📂 Repository           
├── 📂 Service
├── 📂 Web               
```

## 🚀 Setup

### 1. Clone the Repository
```sh
git clone https://github.com/tnhnyldz/NLayerApp.git
cd NLayerApp
```

### 2. Install Dependencies
```sh
dotnet restore
```

### 3. Run the Application
```sh
dotnet run
```

## 🏗️ Software Architecture

This project follows **N Layer Architecture** and **Clean Architecture** principles.

### 📌 N Layer Architecture

N Layer Architecture separates the application into functional layers to improve modularity and maintainability. This project includes the following layers:

- **Caching Layer**
- **Api Logic Layer**
- **CoreLayer Layer**
- **Repository Layer**
- **Service Layer**
-  **UI Layer**
  
### 📌 Clean Architecture

Clean Architecture enforces strict dependency rules, ensuring that business rules remain independent of the system’s infrastructure. This results in a more maintainable, scalable, and testable application.



