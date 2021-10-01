<html>
    <head>
        <title>Wheel of fortune Wheel</title>
        <script src='Winwheel.js'></script>
    </head>
    <body>
        <canvas id='canvas' width='880' height='300'>
            Canvas not supported, use another browser.
        </canvas>
        <script>
            let theWheel = new Winwheel({
                'outerRadius'     : 212,        // Set outer radius so wheel fits inside the background.
                'innerRadius'     : 75,         // Make wheel hollow so segments dont go all way to center.
                'textFontSize'    : 24,         // Set default font size for the segments.
                'textOrientation' : 'vertical', // Make text vertial so goes down from the outside of wheel.
                'textAlignment'   : 'outer',    // Align text to outside of wheel.
                'numSegments'     : 24,         // Specify number of segments.
                'segments'        :             // Define segments including colour and text.
                [                               // font size and text colour overridden on backrupt segments.
                   {'fillStyle' : '#ee1c24', 'text' : '300'},
                   {'fillStyle' : '#3cb878', 'text' : '450'},
                   {'fillStyle' : '#f6989d', 'text' : '600'},
                   {'fillStyle' : '#00aef0', 'text' : '750'},
                   {'fillStyle' : '#f26522', 'text' : '500'},
                   {'fillStyle' : '#000000', 'text' : 'BANKRUPT', 'textFontSize' : 16, 'textFillStyle' : '#ffffff'},
                   {'fillStyle' : '#e70697', 'text' : '3000'},
                   {'fillStyle' : '#fff200', 'text' : '600'},
                   {'fillStyle' : '#f6989d', 'text' : '700'},
                   {'fillStyle' : '#ee1c24', 'text' : '350'},
                   {'fillStyle' : '#3cb878', 'text' : '500'},
                   {'fillStyle' : '#f26522', 'text' : '800'},
                   {'fillStyle' : '#a186be', 'text' : '300'},
                   {'fillStyle' : '#fff200', 'text' : '400'},
                   {'fillStyle' : '#00aef0', 'text' : '650'},
                   {'fillStyle' : '#ee1c24', 'text' : '1000'},
                   {'fillStyle' : '#f6989d', 'text' : '500'},
                   {'fillStyle' : '#f26522', 'text' : '400'},
                   {'fillStyle' : '#3cb878', 'text' : '900'},
                   {'fillStyle' : '#000000', 'text' : 'BANKRUPT', 'textFontSize' : 16, 'textFillStyle' : '#ffffff'},
                   {'fillStyle' : '#a186be', 'text' : '600'},
                   {'fillStyle' : '#fff200', 'text' : '700'},
                   {'fillStyle' : '#00aef0', 'text' : '800'},
                   {'fillStyle' : '#ffffff', 'text' : 'LOOSE TURN', 'textFontSize' : 12}
                ],
                'animation' :           // Specify the animation to use.
                {
                'type'     : 'spinToStop',
                    'duration' : 10,
                    'spins'    : 3,
                    'callbackFinished' : alertPrize,  // Function to call whent the spinning has stopped.
                    'callbackSound'    : playSound,   // Called when the tick sound is to be played.
                    'soundTrigger'     : 'pin'        // Specify pins are to trigger the sound.
                },
                'pins' :                // Turn pins on.
                {
                'number'     : 24,
                    'fillStyle'  : 'silver',
                    'outerRadius': 4,
                }
            });

            // Loads the tick audio sound in to an audio object.
            let audio = new Audio('tick.mp3');

            // This function is called when the sound is to be played.
            function playSound()
            {
                // Stop and rewind the sound if it already happens to be playing.
                audio.pause();
                audio.currentTime = 0;

                // Play the sound.
                audio.play();
            }

            // Called when the animation has finished.
            function alertPrize(indicatedSegment)
            {
                // Display different message if win/lose/backrupt.
                if (indicatedSegment.text == 'LOOSE TURN') {
                alert('Sorry but you loose a turn.');
                } else if (indicatedSegment.text == 'BANKRUPT') {
                alert('Oh no, you have gone BANKRUPT!');
                } else {
                alert("You have won " + indicatedSegment.text);
                }
            }
        </script>
    </body>
</html>