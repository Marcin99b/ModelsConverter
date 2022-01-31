## 1. - Choose your first task

Go to [issues](https://github.com/Marcin99b/ModelsConverter/issues) and choose what you would do.  
I reccomend issues with label "Good first issue"  

## 2 - Fork repository

Click "Fork" (it should be in right-top corner) and github should do everything automatically.  
If you have any problems, there is link to [official tutorial how to fork a repo](https://docs.github.com/en/get-started/quickstart/fork-a-repo).

## 3 - Create branch for your task

There is convention for branch name prefixes
- `feature/` - for creating and extending functionalities (it may contain tests)
- `bugfix/` - for solving bugs, without changing behavior of functionalities
- `test/` - for creating tests to features, without changing behavior of functionalities  

I recommend to use format of name `{issueID}-{issueName}`

For example 
- `feature/123-create-new-converter`
- `bugfix/321-fix-duplicated-output`

As "without changing behavior of functionalities" I mean changes in code that don't modify what user see, for example if you added additional features to code, so user has more possiblities, code should be in feature branch.

## 4 - Pull request

If task is done, create pull request 
- from `your branch` in `forked repo`  
- to `main` branch in `main repo`

Fill form in right side
- assign yourself
- link issue
- wait for comments or approvement

## Code conventions

- use `this` everywhere you can
- use `this` over underscore
- interfaces make code more testable
- use singletons over static classes
- extension methods are good for very simple logic
- every unit test should be dedicated to test one method and check one thing (I recommend using more than one examples of test data)
- unit tests should be named in convention MethodName_WhatIsExpected(), for example RenderProperty_ShouldContainTypeName()
- tests don't contains tricks like using sleep() instruction etc

(todo - add more conventions)
