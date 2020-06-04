# EFPerformanceIssueRepoduction
Code used to reproduce a memory issue in EntityFramework


**Performance issue**
![image](https://user-images.githubusercontent.com/26865926/83755350-bf56bc00-a66d-11ea-912d-a2d7dc0dd6c9.png)

ID 1 = 20mb
ID 2 = 40mb
ID 3 = 60mb
ID 4 = 80mb
ID 5 = 100mb

What we can clearly see is that find without running the async method, it takes between 150 to 350ms, but async are taking between 13000ms to 280000ms

**Memory Issue**
![image](https://user-images.githubusercontent.com/26865926/83756787-d4344f00-a66f-11ea-8023-b2aec2db6be3.png)
With 2 mb binary data Find uses about 52 mb
With 2 mb binary data FindAsync uses about 96 mb
With 20 mb binary data Find uses about 63 mb
With 20 mb binary data FindAsync uses about 432 mb
