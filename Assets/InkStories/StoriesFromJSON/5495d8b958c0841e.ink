VAR StoryTittle = ""
VAR StoryQuestion = "Which one do I choose?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0RelationshipSc = "Crush"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 22

VAR Character0HappinessCh = 0
VAR Character0StrengthCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HealthCh = 0

My work needs people to work the upcoming holidays and I have to choose one.
Which one do I choose?
* [Christmas Eve]
    -> res1
* [Christmas Day]
    -> res2
* [New Year's Eve]
    -> res3
* [New Year's Day]
    -> res4

=== res1 === 
I work Christmas Eve and end up missing %FullName:NPC:1%'s party that %Pron:1:1% invited me to.
~TextForLog = "%FullName:NPC:1% is so mad at me for picking Christmas Eve and missing %Pron:1:3% party. I am wishing I picked a different day now too. I forgot about the party! And most of my shift I ended up having to lug boxes around and rearrange stuff. What a day! At least I got some money."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0WealthCh = "%100%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
I feel bummed out for missing out on my friends and family's activities this day, but I make a bunch of money.
~TextForLog = "%FullName:NPC:1% has a party on Christmas Eve that I go to and that's fun, but missing Christmas Day entirely because I had to work, this just bums me out. The only redeeming factor is that I made a ton of money."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%150%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I work New Year's Eve and still get out with plenty of time to hang out with friends!
~TextForLog = "This turned out to be a good holiday season! %FullName:NPC:1% had %Pron:1:3% Christmas Eve party, I was off Christmas Day, worked New Year's Eve and still had time to hang out with friends. I think I made the right choice for work!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%75%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
I get to do everything I want over the holidays, but I am so wiped out working New Year's Day. All I want to do is sleep!
~TextForLog = "%FullName:NPC:1%'s Christmas Eve party, a long Christmas Day, a VERY LONG New Year's Eve... this was a great time. But I hardly slept and then had to go into work New Year's Day. I just want the day to be over so I can go home. But hey, I had a good time. Even if I am feeling a slight bit ill."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0StrengthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%50%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
