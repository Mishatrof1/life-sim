VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 22
VAR Character0MaxAgeSc = 35
VAR NPC0RelationshipSc = "Crush"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 22
VAR NPC0MaxAgeSc = 35

VAR Character0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0

After a date with %FullName:NPC:1% from the office, we are back at %Pron:1:2% place and my stomach starts grumbling.
What should I do?
* [Nothing, it will probably go away.]
    -> res1
* [Head to %Pron:1:2% bathroom and try to wait it out.]
    -> res2
* [Ask if %FullName:NPC:1% has any antacids.]
    -> res3

=== res1 === 
We start to kiss and my stomach grumbles and %FullName:NPC:1% is completely turned off.
~TextForLog = "I was really hoping it would just go away but right as we start to kiss my stomach grumbles even louder... several times. %FullName:NPC:1% is completely turned off and says we should call it a night. I am so embarrassed and so annoyed with myself. What did I eat at dinner?!"
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
I end up being in %FullName:NPC:1%'s bathroom for so long %Pron:1:1% gets weirded out.
~TextForLog = "%FullName:NPC:1% thinks it's weird that I spend so much time in the bathroom and asks me to leave once I come out. Also %Pron:1:1% tells everyone in our office about the situation and now everyone thinks I'm a creep!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
I'm embarrassed at first but %FullName:NPC:1% tells me not to worry and gets me some antacids.
~TextForLog = "Wow, I just asked %FullName:NPC:1% and it wasn't all that embarrassing at all. %Pron:1:1% provides me with an antacid and my stomach growling goes away. And then we continue to have a great rest of the night!"
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
