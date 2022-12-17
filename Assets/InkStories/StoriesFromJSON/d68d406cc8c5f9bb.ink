VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Male"
VAR NPC1OccupationSc = "HigherInPosition"

VAR NPC0RelationshipCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0

My boss offers me 4 hours of overtime today but my husband and I were supposed to watch a movie tonight.
What do I do?
* [Take the overtime and tell my husband I’ll be home late]
    -> res1
* [Turn down the overtime and head home to watch the movie]
    -> res2
* [Suggest to my husband we watch the movie tomorrow and take the overtime]
    -> res3
* [Ask my boss to just do 2 hours of overtime so I don’t get home too late]
    -> res4

=== res1 === 
My boss is glad I take the overtime and it’s good for my career but my husband is really mad.
~TextForLog = "Things are looking really good at my job and with my boss but things are rocky with my husband since I cancelled our plans."
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My husband is happy we do our movie night together and we have a great time.
~TextForLog = "There will probably be plenty of overtime in the future, me and my husband had a movie night planned and I’m glad I kept our plans, we had a fantastic night!"
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
My husband is more than happy with this decision and my boss is happy with me too, but I forget to get myself dinner.
~TextForLog = "My husband was alright with changing the night and was happy with me for communicating that with him, things are looking good at work too but I am starving! I forgot to eat!"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
My boss gets mad and says it’s 4 hours or nothing, so I take the 4 hours but my husband gets upset with me for ditching him.
~TextForLog = "I didn’t realize my boss would get so angry with me so I just did the full 4 hours. My husband got mad at me too so I guess everyone just hates me... but it’s good for my career... I guess?"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
