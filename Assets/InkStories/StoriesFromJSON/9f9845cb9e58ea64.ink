VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Blue"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 22

VAR Character0HappinessCh = 0
VAR Character0EnduranceCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HealthCh = 0
VAR NPC0SympathyCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0

I'm at the beach with %FullName:NPC:1% and I am in the water and a wave comes, tosses me upside down and pulls my bathing suit off!
What should I do?
* [Run to our spot on the beach and try to cover up]
    -> res1
* [Try to grab my bathing suit in the water]
    -> res2
* [Grab some seaweed to cover myself up]
    -> res3

=== res1 === 
I sprint through the beach and only a few people notice me before I get to our spot and %FullName:NPC:1 gives me clothes to cover up with.
~TextForLog = "That was the fastest I ever ran on the beach and only a few people noticed I was naked. And %FullName:NPC:1% reacted so quickly by giving me clothes to cover up with, this crisis was mostly averted. Thank goodness for %Pron:1:2%."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
I try to grab my suit and more waves come in and flip me upside down again and toss me out onto the beach while I'm naked.
~TextForLog = "I thought I could quickly grab my suit but staying the water longer just made things worse. The ocean tossed me out onto the sand naked! I even tweaked my wrist when I landed. Then, I had to try to run back to our spot and get something to cover up with but so many people on the beach saw me. I'm so embarrassed."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I manage to grab a lot of seaweed and walk myself back to our spot and everyone on the beach notices me but I am completely covered.
~TextForLog = "Everyone on the beach is laughing and watching me. I'm not bothered though, I would stare if I was them too. I'm just glad I got enough seaweed to cover myself up and was able to walk back to our spot so I could properly cover myself up. Also, word of my seaweed ways spreads like wildfire."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END
