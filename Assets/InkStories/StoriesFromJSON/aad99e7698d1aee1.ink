VAR StoryTittle = ""
VAR StoryQuestion = "Should I invite %FirstName:NPC:1%, the class bully?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "Kid:PrimarySchool"
VAR Character0MinAgeSc = 4
VAR Character0MaxAgeSc = 5
VAR NPC0RelationshipSc = "Enemy"
VAR NPC0OccupationSc = "Classmate"
VAR NPC0GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR Character0WisdomCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

It's my birthday party and I am writing out my list of who I'm going to invite...
Should I invite %FirstName:NPC:1%, the class bully?
* [No way. He is a bully! We stand up to bullies!]
    -> res1
* [Invite him - keep your friends close, and your enemies closer. ]
    -> res2
* [Don't invite %FirstName:NPC:1%, but tell him it was an accident. ]
    -> res3

=== res1 === 
When %FirstName:NPC:1% found out that he didn't get an invite, he cornered me in the playground. I told him that it was what he deserved and before he could do anything, I went inside. It's not over. 
~TextForLog = "I stood up to a bully today! %FirstName:NPC:1% was not invited to my party, and it was worth it just to see the look on his face. But... I've made %FirstName:NPC:1% more of an enemy than ever now. "
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:1:+%"
~Character0PopularityCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res2 === 
%FirstName:NPC:1% was happy to have been invited, but at the party he was at his usual tricks. Nothing really bad happened, but a lot of my friends wondered why I had let him come. 
~TextForLog = "I invited the class bully, %FirstName:NPC:1%, to my party. My popularity with the rest of the class took a real bashing, but at least %FirstName:NPC:1% is less likely to duck my head in the toilet again. "
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:1:-%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res3 === 
I tried to tell %FirstName:NPC:1% that I had forgotten to write him an invite, but he didn't believe me. My classmates think I was going to invite the guy who has been making their lives awful. Oh no!
~TextForLog = "White lies can backfire - better to be straight with people, especially if they are bullies who you are not inviting to your party. I guess I've learned my lesson. "
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:1:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:2:-%"
* [Ok]
-> END
