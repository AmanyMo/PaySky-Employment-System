This is a micro Employment syetem fro PaySky Organization.
it contains till now 2 main users (Employer, Applicant).

-Employer::


-Applicant::


Structure::
this mini  project follow clean,CQRS arch as we have separate layers for PResentation , Application,Domain, and Infrastructure.
each layer responsible for specific role/job 
as:: - the Presentation layer => for API(first steo  the request go to)
     - the Application layer => where the logic are exist
     - the Infrastructure layer=> responsible for connection with Db
     - the Domain layer => most independable(isolated/Abstarct) layer which not depend on any other layer/project ,define the main entities.







******************************************************

<<DB>>
This Is the Db Script use it to run db and create tables and relation between them ,
  or just create Db and from code migrate it and will create db tables and it relation.


*******************************************************
