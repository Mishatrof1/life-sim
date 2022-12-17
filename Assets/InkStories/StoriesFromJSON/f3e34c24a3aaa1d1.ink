VAR StoryTittle = ""
VAR StoryQuestion = "What should I have %Pron:1:2% do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR NPC0RelativesSc = "Kid:AdoptedKid"
VAR NPC0MinAgeSc = 6
VAR NPC0MaxAgeSc = 14
VAR NPC1OccupationSc = "HigherInPosition"

VAR NPC0RelationshipCh = 0
VAR Character0PopularityCh = 0
VAR NPC1RelationshipCh = 0

On ‘Bring Your Kid To Work Day’ my kid is in the office with me.
What should I have %Pron:1:2% do?
* [Type up emails for me]
    -> res1
* [Pull up a chair and teach %Pron:1:2% what I am doing]
    -> res2
* [Draw pictures of my coworkers]
    -> res3
* [Let %Pron:1:2% choose to do whatever %Pron:1:1% wants]
    -> res4

=== res1 === 
We have a fun time together but my kid sends out an unprofessional email on my behalf.
~TextForLog = "My kid and I have a fun time and I’m glad %Pron:1:1% enjoyed %Pron:1:5% but I probably should’nt have had %Pron:1:2% send out emails because one of those emails was unprofessional and went to an important client. Can I blame it on ‘Take Your Kid To Work Day’?"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My kid gets really interested in what I’m doing and we bond and have a good time and %Pron:1:1% actually helps me finish my work quickly.
~TextForLog = "It was great having my kid pull up a chair and work with me and %Pron:1:1% really seemed to absorb a lot. And %Pron:1:1% is so smart that %Pron:1:1% caught on quickly and helped me finish my work fast!"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
My kid draws a picture of my boss that is unflattering, all my coworkers find it hilarious but my boss gets angry and I chastise my kid.
~TextForLog = "I had to give my kid a stern talking to which really upset %Pron:1:2% but the unflattering picture %Pron:1:1% drew of my boss was really bad and got my boss quite angry. Everyone else seemed to love it and cheered me on quietly on the side."
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
My kid offers to help everyone in the office and brings my boss and coworkers snacks from the kitchen and they all love it!
~TextForLog = "My kid was great today, helping everyone out however %Pron:1:1% could, bringing people snacks, they all loved %Pron:1:2% and now they all love me too!"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
