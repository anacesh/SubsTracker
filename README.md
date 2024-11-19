# SubsTracker
**SubsTracker Bot** is a .NET Telegram bot that allows you to track and manage user subscriptions.

1. **Clone the repository**  
   Clone the repository to your local machine and navigate into the project directory:
   ```bash
   git clone https://github.com/anacesh/SubsTracker.git
   cd SubsTracker
      ```

2. **Set up the configuration**  
  Create an  ```appsettings.json``` file in the root of your project. Add your bot token to this file. Here is an example of the content:
   ```bash
     {
      "TelegramBot": {
          "Token": "YOUR_BOT_TOKEN"
      }
   ```
3. **Build and run the project**
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
- **.NET 6.0**.  
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
This project is licensed under the GNU General Public License v3.0. See the [LICENSE](https://github.com/all-licenses/GNU-General-Public-License-v3.0) file for more details.

## Support
If you encounter any issues or have feature requests, feel free to create an [issue](https://github.com/anacesh/SubsTracker/issues) in the repository.

# Change Log
| Date       | Version | Change Description                         |
|------------|---------|---------------------------------------------|
| 2024-11-19 | 0.1.0   | Initial bot setup and configuration added.   |
