VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 23
VAR Character0MaxAgeSc = 45
VAR NPC0OccupationSc = "HigherInPosition"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0WealthCh = 0

My boss %FullName:NPC:1% asks me to stay late to help finish a project and says %Pron:1:1% will give me $200. But I'm hungry and have leftovers waiting at home.
What should I do?
* [Say no, I need to go home to eat.]
    -> res1
* [Accept the offer.]
    -> res2
* [Tell my boss that %Pron:1:1% can buy me dinner and I'll stay.]
    -> res3

=== res1 === 
%FullName:NPC:1% gets mad that I don't stay and help with %Pron:1:3% project but I go home and have a healthy dinner and have a stress-free night.
~TextForLog = "%FullName:NPC:1% gets mad at me as if this is my project. It isn't, this is %Pron:1:3% project that %Pron:1:1% is behind on. And I just don't feel like working overtime. I go home and have my healthy leftovers and have a nice night and unwind after work. Just the way I like."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:1% gives me $200 cash, so no taxes here. I stay late and help %Pron:1:2% with the project but I am drained by the end of it and starving and feel weak.
~TextForLog = "%FullName:NPC:1% is so thankful I stayed and helped %Pron:1:2%. Really got %Pron:1:2% out of a jam. I don't really mind because $200 is worth it, however, I haven't eaten in so long and we're at work for a while, I'm starting to feel weak and faint and I'm wishing I ate something."
~Character0HealthCh = "%ValueRef:1:-%"
~Character0WealthCh = "%200%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I'd rather have food than the money. %FullName:NPC:1% buys me dinner and we stay and finish %Pron:1:3% project and %Pron:1:1% is so thankful.
~TextForLog = "So, %FullName:NPC:1% and I finish %Pron:1:3% project, %Pron:1:1% buys me a big dinner that is delicious so I can save my leftovers for another day. But whatever %Pron:1:1% bought me was so unhealthy. It's alright, it tasted good. And really I just needed to eat something, I couldn't go that long without eating anything."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%%"
~NPC0RelationshipCh = "%%"
* [Ok]
-> END
