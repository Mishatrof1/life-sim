VAR StoryTittle = ""
VAR StoryQuestion = "What numbers should I pick?"
VAR StoryCategory = "Gold"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 18
VAR Character0MaxAgeSc = 65

VAR Character0WealthCh = 0
VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0

I am buying a lottery ticket.
What numbers should I pick?
* [5 17 6 33 2]
    -> res1
* [12 19 3 9 1]
    -> res2
* [4 23 87 7 4]
    -> res3
* [18 5 82 3 10]
    -> res4

=== res1 === 
This ticket wins no money
~TextForLog = "I didn't win anything, oh well, it was only 5 bucks. What was the harm in trying, right?"
~Character0WealthCh = "%-5%"
* [Ok]
-> END

=== res2 === 
I actually won a bit of money because some of the numbers were correct!
~TextForLog = "Hey, I won $50 and I will take it! Not bad at all! I forgot that you don't always have to get all the numbers right to win some money."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%+50%"
* [Ok]
-> END

=== res3 === 
I won a decent amount of money! I got some of the numbers right!
~TextForLog = "Wow! I won $250 because I got some specific numbers correct even though I didn't get all the numbers correct! That's not bad at all!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WealthCh = "%250%"
* [Ok]
-> END

=== res4 === 
The cashier calls the police on me and I am arrested!
~TextForLog = "Apparently, three people before me came in and asked for those exact numbers and it was part of some scam. So, when I asked for those numbers they thought I was with the scammers, they called the police on me and when the police arrived they tackled me to the ground and arrested me and now I need to make bail!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-100%"
* [Ok]
-> END
