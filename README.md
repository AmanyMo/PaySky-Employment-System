This is a micro Employment syetem fro PaySky Organization.
it contains till now 2 main users (Employer, Applicant).

Requirements that applied Untill Now::
1 have 2 users(Role)
2 Each user role have specific functions.
3 shared functions: register/login/search vacancy by text/search vacancyById/ GetAllVacancies
4 Employer ::
       - CRUD op for vacancy
        - Vacancy has  max number & expiry date
          - View list of applicants 
5 Applicant user ::
          - Search for vacancy.
            -Apply for vacancy
6 logging
7 Exception Handling
8 Clean Arch CQRS
9 caching on limited range only 4-5 functions 

----------------------------------------------------------------------------------------------------------

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

To see the token data , use this site ::
https://jwt.io/

****************************************************************

**DOWNLOAD AND RUN **
-clone the repo
-make sure that connection String is correct.
-run db script or make Migration(add-migration Migv1  **then** update-database)
-run and test with Swagger Api
-Swagger is Authenticated , so you need to register and login first and take the returned Token and pass it in Auth fiels in each endpoint to be ablr to run that endpoint
  make sure that you take the right token  as each user has a different token , Applicant token open some endpoints and Employer open other and there are shared endpoint between them.

-----------------------
Postman Link::
https://speeding-spaceship-2568.postman.co/workspace/My-Workspace~5b276006-822d-4c8e-8f02-702680a1a18f/collection/10465914-7dbd3c20-e5fc-45ce-a673-fec4c69afac1?action=share&source=copy-link&creator=10465914
