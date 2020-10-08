# Install docker
 https://medium.com/@nitinbhardwaj6/selenium-grid-with-docker-c8ecb0d8404

## pull docker images:

```sh
$ docker pull selenium/hub
$ docker pull selenium/node-chrome
```

## Set up infrastructure using docker-compose.

```sh
version: "3"
services:

  hub:
    image: selenium/hub
    ports:
      - "4444:4444"

    environment:
      GRID_MAX_SESSION: 16
      GRID_BROWSER_TIMEOUT: 3000
      GRID_TIMEOUT: 3000

  chrome:
    image: selenium/node-chrome
    container_name: web-automation_chrome
    depends_on:
      - hub
    environment:
      HUB_PORT_4444_TCP_ADDR: hub
      HUB_PORT_4444_TCP_PORT: 4444
      NODE_MAX_SESSION: 4
      NODE_MAX_INSTANCES: 4
    volumes:
      - /dev/shm:/dev/shm
    ports:
      - "9001:5900"
    links:
      - hub

  firefox:
    image: selenium/node-firefox
    container_name: web-automation_firefox
    depends_on:
      - hub
    environment:
      HUB_PORT_4444_TCP_ADDR: hub
      HUB_PORT_4444_TCP_PORT: 4444
      NODE_MAX_SESSION: 2
      NODE_MAX_INSTANCES: 2
    volumes:
      - /dev/shm:/dev/shm
    ports:
      - "9002:5900"
    links:
      - hub
```

## start docker compose
```sh
$ docker-compose -f /path/to/docker-compose.yml up -d
 ```
 
 ## stop docker compose
 ```sh
 $ docker-compose -f /path/to/docker-compoes.yml down
 ```
 
# Code structure:
```sh
root
  ---TestCase
      ---TestPackage (ex: PersonalUI, MobileUI, AddminUI...)
         ---TestSuite1 (ex: Login, SubmitPosting, EditPosting...)
            ---TestSuite1Page.cs (ex: LoginPage)
            ---TestSuite1PageTest.cs (ex: LoginPageTest)
            ---TestSuite1PageTestFactory.cs (ex: LoginPageTestFactory)
         ---TestSuite2
         ...
```

- TestSuitePage: implement Page Object Model pattern
- TestSuitePageTest: inherite TestSuitePage class. implement use case logical.
- TestSuitePageTestFactory: inherite ITestSuitePageFactory. generate test all case on many enviroments (browser) by requirement

# Code Guidline

- To exclude test suite to avoid auto run test: add Obsolete attribute to factory class.
- Walk from page to page: init the pages with same driver and call their actions to walk to other page.
```c#
var driver = driverManager.getDriver();

var loginPage = new LogInPage(driver);
loginPage.login();

var changePassPage = new ChangePassPageTest(driver);
changePassPage.ChangePass(oldPass, newPass, confirmPass);

```
 
