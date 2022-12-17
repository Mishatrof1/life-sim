VAR StoryTittle = ""
VAR StoryQuestion = "Which professor should I go with?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "College"
VAR Character0MinAgeSc = 18
VAR Character0MaxAgeSc = 23

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0
VAR Character0WisdomCh = 0

I'm going to take a Philosophy class and am trying to decide which one to take.
Which professor should I go with?
* [Professor Johnson]
    -> res1
* [Professor Jackson]
    -> res2

=== res1 === 
The first day of class Professor Johnson assigns us a load of homework.
~TextForLog = "Wow, first day of class and I got a load of homework. This is a bummer, my whole weekend is ruined. But there is a lot of interesting things assigned to us and I suppose I do learn a lot."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
Professor Jackson feels e learn best by being out in the world so the first day we are to just go wander the campus and ponder some things.
~TextForLog = "At first this felt like a free period and I was so happy to just be able to wander around outside but then I realized the point was to really ponder some critical questions in life and I really become enlightened. This might've been the best class I ever had. And I wasn't even in a class!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
* [Ok]
-> END
