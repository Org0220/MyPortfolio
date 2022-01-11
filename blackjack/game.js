var playerScore;
var dealerScore;
var gameOver = false;
var playerWon = false;
var deck;
var cardNum;
function deal() {
    playerScore = 0;
    dealerScore = 0;
    gameOver = false;
    playerWon = false;
    deck = [];
    updateDeck();
    disableButtons(false);
    document.getElementById("player1").src = "img/"+ getCardNum("playerHand") + ".png";
    document.getElementById("player2").src = "img/"+ getCardNum("playerHand") + ".png";
    document.getElementById("dealer1").src = "img/"+ getCardNum("dealerHand") + ".png";
    document.getElementById("dealer2").src = "img/"+ getCardNum("dealerHand") + ".png";
    winCondition();
}

function requestPlayerCard() {
    addCart("playerHand");
    winCondition();
}
function completeDealerHand() {
    while (dealerScore <= 16)
        addCart("dealerHand");
    if (dealerScore > 21)
        won("playerLabel");
    else if(dealerScore > playerScore)
        won("dealerLabel");
    else if(dealerScore < playerScore)
        won("playerLabel");
    else if(dealerScore == playerScore)
    {
        document.getElementById("playerLabel").innerHTML = "Player is a draw";
        disableButtons(true);
    }
     disableButtons(true);
}

function winCondition() {
    if(playerScore == 21)
        won("playerLabel");
    else if (dealerScore == 21)
        won("dealerLabel");
    else if (dealerScore > 21)
        won("playerLabel");
    else if (playerScore > 21)
        won("dealerLabel");
}


function won(location) {
    let span = document.createElement("span");
    let winner = document.getElementById(location).innerHTML;
    document.getElementById(location).innerHTML = "";
    span.style = "background-color:#00FF00";
    span.innerHTML = winner;
    document.getElementById(location).appendChild(span);
    document.getElementById(location).innerHTML += "has won the hand";
    disableButtons(true);
}

function draw() {
    
    disableButtons(true);
}

function labelValueChange(location, text) {
    let span = document.createElement("span");
    let winner = document.getElementById(location).innerHTML;
    document.getElementById(location).innerHTML = "";
    span.style = "background-color:#00FF00";
    span.innerHTML = winner;
    document.getElementById(location).appendChild(span);
    document.getElementById(location).innerHTML += text;
    disableButtons(true);
}

function disableButtons(disable) {
    document.getElementById("btnDraw").disabled = disable;
    document.getElementById("btnHold").disabled = disable;
}

function getCardValue(cardNum) {
        while (cardNum > 13) {
            cardNum -= 13;
        }
        if (cardNum == 1)
            return 11;
        if(cardNum == 11 || cardNum == 12 || cardNum == 13)
            return 10;
        return cardNum;
}

function updateDeck() {
    for(var i = 1; i <= 52; i++)
        deck.push(i);
}

function getCardNum(location) {
    let num;
    let removedValue = 0;
    while (removedValue == 0){
        num = Math.trunc(Math.random() * 52) + 1;
        for(i in deck){
            if(num == i) {
                removedValue = deck.splice(i,1);
                break;
            }
        }
    }
    if(location == "dealerHand"){
        dealerScore += parseInt(getCardValue(removedValue));
        document.getElementById("dealerScore").innerHTML = dealerScore;
    }
    else if(location == "playerHand") {
        playerScore +=  parseInt(getCardValue(removedValue));
        document.getElementById("playerScore").innerHTML = playerScore; 
    }
    
    return removedValue;

}

function addCart(location) {
    let card = document.createElement("img");
    card.src = "img/"+ getCardNum(location) +".png";
    let playerHand = document.getElementById(location);
    playerHand.appendChild(card);
}

function placeStartingCards(location, card) {

}

