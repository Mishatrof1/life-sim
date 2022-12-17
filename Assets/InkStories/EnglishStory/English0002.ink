VAR AgeMinCondition = 5
VAR AgeMaxCondition = 7
VAR SexCondition = "Female"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I want to start wearing makeup but I don't have any. What should I do? 
* [Ask some makeup from a high school girl I know and apply it to my face]
    -> res1
* [Get some of mom's makeup and apply it to my face]
    -> res2
* [Steal some cosmetics from a shop]
    -> res3
* [Use my paints for art classes as make-up]
    -> res4

=== res1 === 
That girl laughed at me and then put make-up on me herself. Love it! 
~TextForLog = "I wanted to wear make-up and asked one of the older girls to help me. I really loved the result."
* [Ok]
-> END
=== res2 === 
Mom sent a picture of me to her friends to laugh. That hurt! 
~TextForLog = "I wanted to wear make-up, so I got some of Mom's and put it on. Mom took a photo of me and sent it to her friends to make fun of me."
* [Ok]
-> END
=== res3 === 
The security caught me, there was a huge scandal! I feel so ashamed
~TextForLog = "I wanted to wear make-up, so I stole some in a shop. I got caught, and it was a great  scandal."
* [Ok]
-> END
=== res4 === 
The pictures of me went viral on the Internet. It sucks!
~TextForLog = "I wanted to wear make-up and applied some of my art classes stuff to my face. I'm an Internet meme now. Life is pain!"
* [Ok]
-> END