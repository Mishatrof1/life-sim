VAR StoryTittle = ""
VAR StoryQuestion = "%Pron:1:1% tells me I should call out sick as well. What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0OccupationSc = "Colleague"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 22

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

My coworker %FullName:NPC:1% tells me %Pron:1:1% is calling out sick to work today to go to an amusement park.
%Pron:1:1% tells me I should call out sick as well. What should I do?
* [Don't call out sick, go to work.]
    -> res1
* [Call out sick.]
    -> res2

=== res1 === 
%FullName:NPC:1% is alright with this and I go to work but I feel like I missed out.
~TextForLog = "I am somewhat glad I worked, since I was able to earn some money. But I can't help feeling like I missed out on an opportunity to spend some time with %FullName:NPC:1% at an amusement park and %Pron:1:1% seemed to have so much fun. I was just afraid that work would catch on if we both called out sick."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%60%"
* [Ok]
-> END

=== res2 === 
I go to the amusement park and have a great time and no one at work is suspicious at all!
~TextForLog = "Me and %FullName:NPC:1% have such a fantastic day together, we really start to connect a lot. And I was afraid we would both get caught if we both called out sick but no one at work suspected a thing. Sure, I didn't make money and instead spent money at the amusement park, but I think it was absolutely worth it!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-30%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
