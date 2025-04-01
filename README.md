# SAI.LogModule - Logging Configuration in .NET

## 📌 Contents
- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [Error Handling](#error-handling)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [License](#license)
- [Author](#author)
- [Disclaimer](#disclaimer)

---

## 📖 Overview
**SAI.LogModule** is a powerful and flexible logging module for .NET applications. It allows developers to configure structured logging using **Serilog** with various output formats, including console and file logs. The package is available on **NuGet** and supports detailed logging with **component-based structured messages**.

The module is open-source and can be downloaded from GitHub for customization.

🔗 **GitHub Repository:** [https://github.com/KambizShahriary/SAI.LogModule](https://github.com/KambizShahriary/SAI.LogModule)

---

## 🚀 Features
- ✅ **Easy-to-use**: Simple integration into .NET projects.
- 📄 **Configurable Logging**: Supports JSON-based logging configuration.
- 🔥 **Serilog Support**: Integrates with Serilog for structured logging.
- 🔁 **Multiple Sinks**: Logs can be written to console and file simultaneously.
- 📊 **Component-based Logging**: Adds structured logging with `ComponentName`.
- 🔐 **Customizable Output Format**: Fully configurable output template.
- ⚡ **Performance Optimized**: Lightweight and optimized for high-speed logging.

---

## 🛠 Getting Started
### Prerequisites
- **.NET 6, .NET 7, .NET 8, or .NET 9**
- **Serilog NuGet Package** (included in this module)

### Installation
Install the package via NuGet:

```shell
Install-Package SAI.LogModule
```

Or via .NET CLI:

```shell
dotnet add package SAI.LogModule
```

---

## ⚙️ Configuration
To configure the logging module, modify the `appsettings.json` file as follows:

```json
{
  "LogConfig": {
    "LogServiceFilePath": "logs/ServiceLog-.txt",
    "AddSerilog": false,
    "FixedLengthForComponentName": 25
  },
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Information",
        "System": "Information",
        "Microsoft.Hosting.Lifetime": "Information",
        "Microsoft.AspNetCore": "Information",
        "Microsoft.EntityFrameworkCore": "Information"
      }
    },
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
          "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] | {ComponentName}{SourceContext} |{Message:lj} > (in {MemberName} at line {LineNumber}){NewLine}{Exception}"
        }
      },
      {
        "Name": "File",
        "Args": {
          "path": "logs/ServiceLog-.txt",
          "rollingInterval": "Day",
          "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] | {ComponentName}{SourceContext} | {Message:lj} > (in {MemberName} at line {LineNumber}){NewLine}{Exception}"
        }
      }
    ],
    "Enrich": [ "FromLogContext" ],
    "Properties": {
      "Application": "PlatformTrade"
    }
  }
}
```

### 📄 Key Configurations:
- **LogServiceFilePath**: Defines the log file location.
- **AddSerilog**: Enables or disables Serilog logging.
- **FixedLengthForComponentName**: Specifies fixed length for component name formatting.
- **WriteTo**: Configures output destinations (console and file).
- **RollingInterval**: Rotates log files daily.
- **Enrich**: Adds contextual information to logs.
- **Application Property**: Identifies application logs.

---

## 📌 Usage

### 🔹 Basic Implementation

```csharp
using SAI.LogModule;

services.CreateLogsManager(configuration);

logger.LogInformation("Application started successfully!", "Configuration");
```

### 🔹 Logging with Components
```csharp
ILogsManager.Information("User authentication successful.", "AuthService");
ILogsManager.Warning("Database query w.", "DatabaseService");
```

---

## ❌ Error Handling
This module provides structured error logging. Exceptions are logged with full details including the **method name, line number, and component context**.

```csharp
try
{
    throw new Exception("Test Exception");
}
catch (Exception ex)
{
    SaiLogger.LogError($"An error occurred during login. {ex}", "AuthService");
}
```

Example Output:
```
2024-04-01 12:00:00.123 [ERR] | AuthService | An error occurred during login. Exception: System.Exception: Test Exception > (in LoginUser at line 42)
```

---

## 🖥️ Technologies Used
- **.NET (6, 7, 8, 9)**
- **Serilog for Logging**
- **JSON Configuration for Flexibility**
- **Dependency Injection Support**

---

## 🤝 Contributing
We welcome contributions! Feel free to submit a **pull request** on GitHub.

---

## 📜 License
This project is licensed under the **MIT License**.

---

## 👤 Author
**Kambiz Shahriarynasab**  
📧 [saiprogrammerk@gmail.com](mailto:saiprogrammerk@gmail.com)  
🔗 [Telegram](https://t.me/pr_kami)  
📷 [Instagram](https://www.instagram.com/pr.kami.sh/)  
📺 [YouTube](https://www.youtube.com/channel/UCqjjdsFRXliDa7K612BZtmA)  
💼 [LinkedIn](https://www.linkedin.com/public-profile/settings?trk=d_flagship3_profile_self_view_public_profile)

---

### ⚠️ Disclaimer
The author assumes no responsibility for any issues, damages, or losses that may arise from the use of this code. The project is provided **"as is"** without any warranties. Users should verify the implementation in their environments before deploying it in production.

