# CalendarX

Simple aspnet webapp with aurelia front-end for university events

CalendarX folder contains ASP.NET Core 3.1 project

Business logic lives in BLL tagged folders and the Data Access Layer is in the DAL tagged folders.

ClientApp folder contains the Aurelia frontend client written with typescript.


The server has a functioning dockerfile within it, but the client dockerfile is not ready yet.

4 projects were deleted and uploaded to nuget instead, and used as imports:

ee.itcollege.jarootnuget.BLL.Base,

ee.itcollege.jarootnuget.Contracts.Base,

ee.itcollege.jarootnuget.Contracts.BLL.Base,

ee.itcollege.jarootnuget.Contracts.DAL.Base,

ee.itcollege.jarootnuget.DAL.Base.EF
