VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR NPC0RelativesSc = "Sibling:StepSibling"
VAR NPC0GenderSc = "Male"
VAR NPC0MinAgeSc = 9
VAR NPC0MaxAgeSc = 16
VAR NPC1OccupationSc = "Classmate"

VAR Character0HealthCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0PopularityCh = 0

My brother says he sees my acquaintance %FirstName:Npc:2% wearing my missing shirt at school and thinks %Pron:1:1% stole it.
What do I do?
* [Tell my brother he’s wrong]
    -> res1
* [Decide to ask %FirstName:Npc:2% where %Pron:1:1% got %Pron:1:3% shirt]
    -> res2
* [Confront %FirstName:Npc:2% about stealing my shirt.]
    -> res3
* [Bring my brother to go beat up %FirstName:Npc:2%]
    -> res4

=== res1 === 
My brother and I get in a big argument that turns into a fight. We both get grounded and I spend the rest of the night in my room doing homework.
~TextForLog = "I can’t believe my brother accused %FirstName:Npc:2% of stealing my shirt, we got in a huge fight and our parents grounded us. I’m so annoyed. Plus, I still can’t find that shirt!"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FirstName:Npc:2% tells me the store %Pron:1:1% bought it at and we bond over the shirt. My brother calls to tell me he found my shirt and apologizes.
~TextForLog = "I’m glad I went and talked to %FirstName:Npc:2% because it turns out %Pron:1:1% just bought the same shirt as me. And my brother found my shirt and apologized to me which was nice of him."
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
Get in a fight with %FirstName:Npc:2% but %Pron:1:1% beats me up and a lot of kids at school make fun of me. My brother finds my shirt and we get in a big fight also.
~TextForLog = "My stupid brother told me %FirstName:Npc:2% stole my shirt and it turns out my shirt was at home all along. I’m mad at my brother, %FirstName:Npc:2% is mad at me and I have a black eye!"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
My brother and I go beat up %FirstName:Npc:2% but the kids at school call it an unfair fight. Later on my brother and I find my shirt at home.
~TextForLog = "My brother and I gang up on %FirstName:Npc:2% and then it turns out he didn’t steal the shirt. We aren’t the most popular kids at school now but we do bond over the event. Maybe next time I’ll be more careful though."
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
