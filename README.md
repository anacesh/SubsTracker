# SubsTracker
**SubsTracker Bot** is a .NET Telegram bot that allows you to track and manage user subscriptions.

1. **Clone the repository**  
   Clone the repository to your local machine and navigate into the project directory:
   ```bash
   git clone https://github.com/anacesh/SubsTracker.git
   cd SubsTracker
      ```

2. **First run configuration**  
  On the first run, the bot will automatically generate the ```appsettings.json``` file if it is missing.
  The bot will prompt you to input your Telegram Bot Token during startup.  
  The token will be saved in the generated appsettings.json file for future use.  
   ```bash
     {
      "TelegramBot": {
          "Token": "YOUR_BOT_TOKEN"
      }
   ```
4. **Build and run the project**
   Run the following commands to build and start the bot:
   ```bash
   dotnet build
   dotnet run
   ```

## Project Structure
- ```Bot/```: Contains the core logic for the Telegram bot.
- ```Subs/```: Manages subscriptions.
- ```Users/```: Handles user-related functionality.
- ```Logs/```: Handles log files functionality.
- ```Src/```: A general-purpose folder for source files that.
- Root Directory:
  - ```Program.cs```: The entry point of the application.  
  - ```appsettings.json```: Configuration file for sensitive information.

## Requirements
The following tools, libraries, and frameworks are required to run the project:  
- **.NET 8.0+**.  
- **Entity Framework Core**.  
- **Telegram.Bot**.  

You can install the necessary libraries using the .csproj file or by running:  
   ```bash
   dotnet restore
   ```

## Notes
The ```appsettings.json``` file contains sensitive information like your bot token and should not be included in the repository. To prevent this add ```appsettings.json``` to the ```.gitignore``` file (already done in this repository).
Never share or push this file with real credentials to GitHub.

## License  
This project is licensed under the MIT License. See the [LICENSE](https://github.com/anacesh/SubsTracker/blob/master/LICENSE) file for more details.

## Support
If you encounter any issues or have feature requests, feel free to create an [issue](https://github.com/anacesh/SubsTracker/issues) in the repository.

# Change Log
| Date       | Version | Change Description                         |
|------------|---------|---------------------------------------------|
| 2024-11-19 | 0.1.0   | Initial bot setup and configuration added.   |
| 2024-11-20 | 0.1.1   | Added automatic ```appsettings.json``` generation and token prompt.   |
