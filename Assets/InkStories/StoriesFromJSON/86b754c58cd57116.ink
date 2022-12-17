VAR StoryTittle = ""
VAR StoryQuestion = "Shall I continue playing?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "Kid:PrimarySchool"
VAR Character0MinAgeSc = 4
VAR Character0MaxAgeSc = 5
VAR NPC0RelativesSc = "Parent"
VAR NPC0GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0PopularityCh = 0
VAR Character0HealthCh = 0
VAR Character0AthleticismCh = 0
VAR Character0IntelligenceCh = 0

My mom wants me off my tablet... she keeps frowning at me, and looking sad. But I am nearly at a new high score on this game! And she hasn't told me to get off outright yet.
Shall I continue playing?
* [Play for a little longer until Mom actually tells me to stop. ]
    -> res1
* [Sneak off into another room to carry on playing. ]
    -> res2
* [Turn off the tablet. I don't want square eyes. ]
    -> res3
* [Hide in the cupboard under the stairs and smash this new record!]
    -> res4

=== res1 === 
I chose to ignore my Mom's subtle clues and then she yelled at me. I turned off the machine really quickly then! I didn't reach a new high score, and Mom's mad. 
~TextForLog = "Turns out you should always pay attention to your parent's subtle clues. I ignored my mom's wish to get me off my tablet and got told off. "
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
When I snuck off into my bedroom, I won myself at least another five minutes before my mom hunted me down. New high score! But Mom was furious! I'm not allowed my tablet for a week. 
~TextForLog = "A simple trade: tablet time in exchange for being in your mom's bad books. Books is all I'll be looking at for a week now anyway, so I guess I can work it out."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res3 === 
I switched off the tablet and my mom was immediately happier. No high score for me - I was going to top the leader board! Never mind, I had a good time running around outside instead. 
~TextForLog = "I chose my mom and exercise over letting my eyes go square on my tablet. Healthy choices, people!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
It was dark and creepy in there, but my mom couldn't find me! I absolutely smashed the new high score: I'm the best player in the country. When my mom found me though, I've never seen her so angry...
~TextForLog = "I know I shouldn't have done it, but hiding in the cupboard under the stairs gave me time to get a killer high score on my game. I don't know if mom will ever trust me to use the tablet again, but I'm going to enjoy the respect of being top of the country for a while. "
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
