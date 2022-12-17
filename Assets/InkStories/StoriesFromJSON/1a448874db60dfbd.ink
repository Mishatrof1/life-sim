VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0OccupationSc = "Colleague"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 22
VAR NPC1OccupationSc = "Colleague"
VAR NPC2OccupationSc = "HigherInPosition"

VAR Character0HealthCh = 0
VAR NPC2RelationshipCh = 0
VAR Character0HappinessCh = 0
VAR NPC2HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0PopularityCh = 0

I am supposed to work today but I am feeling a bit sick.
What should I do?
* [Take some medicine and go into work.]
    -> res1
* [Call out sick]
    -> res2
* [Ask %FullName:NPC:1% to cover my shift.]
    -> res3
* [Ask %FullName:NPC:2% to cover my shift.]
    -> res4

=== res1 === 
My boss %FullName:NPC:3% sees I am sick and gets mad at me for showing up and sends me home.
~TextForLog = "%FullName:NPC:3% tells me I shouldn't try coming into work when I'm sick, I can get others sick. %Pron:3:1% sends me home. I get home and after all that moving around, going to work, coming back, I am out of breath. It's too much for me in this state and I am worse off than before."
~Character0HealthCh = "%ValueRef:0:-%"
~NPC2RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:3% gets mad at me for calling out and not trying to cover my shift.
~TextForLog = "Wow, I didn't think %FullName:NPC:3% would actually get mad at me for not covering my shift. I called out and wasn't thinking too clearly, it wasn't on the top of my priority list to call someone to cover me. What is %Pron:3:3% problem?!"
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC2HappinessCh = "%ValueRef:0:-%"
~NPC2RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% covers my shift and I stay home and rest.
~TextForLog = "%FullName:NPC:3% is happy I got someone to cover my shift and views me as being very responsible. %FullName:NPC:1% is happy to take the shift too since %Pron:1:1% was looking to work more. And I'm happy to just rest at home and try to sleep this sickness away. I'm already feeling better."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC2HappinessCh = "%ValueRef:0:+%"
~NPC2RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
%FullName:NPC:2% can't work the shift so I go into work anyway.
~TextForLog = "After %FullName:NPC:2% can't work my shift I just go into work. I tell my boss %FullName:NPC:3% and %Pron:3:1% appreciates me trying but tells me I should just go home and rest. Everyone is impressed that I still tried to go into work feeling the way I do, but now I feel worse than before."
~Character0HealthCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC2HappinessCh = "%ValueRef:0:+%"
~NPC2RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
