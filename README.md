# SAOnlineMart
This is an ASP.NET Core MVC Web Application that's running on macOS. For the database, I used MySQL Server, which is running on a Docker container using DBeaver as the db manager since Azure Data Studio gave countless errors.  

VIDEO LINKS  
-----------  
SETUP MYSQL AS DOCKER CONTAINER AND IMAGE: https://www.youtube.com/watch?v=3BFxALltQaM  
CONNECT SQL SERVER TO DOCKER: https://medium.com/@joaooliveira889/executing-a-sql-server-docker-container-and-connecting-to-a-net-4b75cae7df32  
SETUP DATABASE, TABLES, RECORDS, IN DBEAVER: https://www.youtube.com/watch?v=LEx96-CkB1Q  

START AND STOP DOCKER CONTAINER  
-------------------------------  
START DOCKER CONTAINER: `docker-compose up -d`  
STOP DOCKER CONTAINER: `docker-compose down -d`  

MANAGE MIGRATIONS  
-----------------  
TO ADD MIGRATIONS FOLDER:  
`dotnet ef migrations add MigrationName --context ContextFolderName`  
(when multiple DbContext folders, add `--context FileName` in the DbContext folder)  

TO UPDATE DATABASE:  
`dotnet ef database update --context ContextFolderName`  

TO UPLOAD FOLDER TO GITHUB REPO  
-------------------------------  
Watch video or follow steps: https://www.youtube.com/watch?v=dpZQFTXSfjs  
Step 1 - Create a new GitHub Repo on the browser. Set to public and add a ReadMe file.  
Step 2 - Navigate to the 'Code' tab and copy the URL under HTTPS.  
Step 3 - In mac terminal, cd to the folder where you want to clone your repository.  
Step 4 - Type `git clone` and then paste the URL you copied in step 2. After this, you will find the git repo folder created.  
Step 5 - To upload a file(s) to the cloned repo, manually copy files and paste them in the folder using Finder.  
Step 6 - After you've copied the file(s), navigate to the cloned repo folder via terminal using `cd`.  
Step 7 - Type `git lfs install` to install LFS on your computer if not already. LFS is the large file system.  
Step 8 - In the cloned folder, type `git lfs track "*.mov"` (.mov is the file extension of the targeted file).  
Step 9 - Type `git add .`  
Step 10 - Type `git commit -m "LFS"` (text in `""` is the description of what you're committing).  
Step 11 - Type `git push origin main`.  
Step 12 - If prompted, enter your username and password. For the password, use the access token: Settings > Developer Settings > Personal Access Token.
