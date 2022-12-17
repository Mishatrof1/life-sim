VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0OccupationSc = "Colleague"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 35

VAR Character0HealthCh = 0
VAR NPC0SympathyCh = 0
VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR NPC0RelationshipCh = 0

Someone left a whole tray of brownies in the break room and I'm not sure if they're for everyone or not.
What should I do?
* [Don't eat any brownies]
    -> res1
* [Eat one brownie]
    -> res2
* [Eat two brownies.]
    -> res3
* [Eat three brownies.]
    -> res4

=== res1 === 
I was playing it safe and ate no brownies, but it turns out they WERE for everyone.
~TextForLog = "%FullName:NPC:1% made the brownies and left them there for everyone. By the time I found out, they were all gone. But I ate a healthy lunch instead of eating any brownies, so I guess that's good."
~Character0HealthCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
I eat one brownie and it's delicious. I later find out they WERE for everyone.
~TextForLog = "%FullName:NPC:1% made the brownies for everyone and %Pron:1:1% is glad to hear that I thought the brownie was so delicious. Really put me in a good mood!"
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I eat two brownies and it turns out they WERE for everyone. And they were delicious!
~TextForLog = "%FullName:NPC:1% made the brownies for everyone and is pleased to hear that I liked them so much. Those things were almost too delicious. They're deadly if you eat too many."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
The brownies WERE for everyone but everyone thinks I'm a pig for eating so many.
~TextForLog = "So, the brownies were for everyone and %FullName:NPC:1% made them. I loved them, they were so delicious. Obviously since I ate three. But %FullName:NPC:1% gets a little annoyed I ate so many since they were supposed to be for everyone. And everyone else is annoyed with me for pigging out. Whoops!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
