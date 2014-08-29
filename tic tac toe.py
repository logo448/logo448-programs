#Logan Stenzel
#
#4/30-5/ /13
#Tic Tac Toe

#global constants
X="x"
O="O"
TIE="TIE"
EMPTY=" "
NUM_SQUARES=9
parentNodes=[]
leafNodes=[]

#opening a file to write all the data to.
data=open("ticTacToeData", "a")

#functions
def displayInstruct():
    """prints the directions to tic tac toe"""
    print("""
    Welcome to Tic-Tac-Toe

    This will be the ultimate chalange my artificial intellegiance against
    your brain. To pick your square use the grid below.
    

                    0|1|2
                    -----
                    3|4|5
                    -----
                    6|7|8
                    

    Good luck because you don't stand a chance. To win you need to get
    three squares in a row.""")

def askYesOrNo(question):
    """asks yes or no question"""
    response=None
    while response not in ("y","n"):
        response=input(question).lower()
    return response

def askNumber(question,low,high):
    """asks a number between two points"""
    response=None
    while response not in range(low,high):
        response=int(input(question))
    return response

def pieces():
    """determines who goes first"""
    goFirst=askYesOrNo("Do you need the first move? (y/n): ")
    if goFirst=="y":
        print("You will need it")
        human=X
        computer=O
    else:
        print("Your bravery will stab you in the back...")
        computer=X
        human=O
    return computer,human

def newBoard():
    """creates a new game board"""
    board=[]
    for square in range(NUM_SQUARES):
        board.append(EMPTY)
    return board

def displayBoard(board):
    """Displays game board"""
    print()
    print(board[0],"|",board[1],"|",board[2])
    print("---------")
    print(board[3],"|",board[4],"|",board[5])
    print("---------")
    print(board[6],"|",board[7],"|",board[8])

def legalMoves(board):
    """checks if move is legal"""
    moves=[]
    for square in range(NUM_SQUARES):
        if board[square] == EMPTY:
            moves.append(square)
    return moves

def winner(board):
    """checks for winner"""
    WAYS_TO_WIN=((0,1,2),
               (3,4,5),
               (6,7,8),
               (0,3,6),
               (1,4,7),
               (2,5,8),
               (0,4,8),
               (2,4,6))
    for way in WAYS_TO_WIN:
        if board[way[0]] == board[way[1]] == board[way[2]] != EMPTY:
            winner=board[way[0]]
            return winner
    if EMPTY not in board:
        return TIE
    return None

def humanMove(board):
    """gets human move"""
    legal=legalMoves(board)
    move=None
    while move not in legal:
        print()
        move=askNumber("Were will you go 0-8: ",0,NUM_SQUARES)
        if move not in legal:
            print("That square is already taken, pick another one foolish human")
    return move

def gameTree(board,parentNodes,computer,human,turn):
    nodes=legalMoves(board)
    printNodes=str(nodes)
    print("n "+printNodes)
    board=board[:]
    for node in nodes:
        print("node "+str(node))
        print(str(board))
        if turn != computer:
            board[node]=computer
        elif turn != human:
            board[node]=human
        if winner(board)==None and winner(board) != TIE:
            if board not in parentNodes:
                parentNodes.append(board)
                print(str(parentNodes))
        elif winner(board) != None:
            if board not in leafNodes:
                leafNodes.append(board)
        board[node]=EMPTY
    return leafNodes, parentNodes
            
#def minimax(board):
#    turn="max"
#    for move in legalMoves(board):
#        board[move]=computer

def evaluate(board):
    if winner(board)==computer:
        moveScore=1
    elif winner(board)==human:
        moveScore=-1
    elif winner(board)==TIE:
        moveScore=0
    return moveScore        

def computerMove(board,computer,human):
    """gets computers move"""
    #get a mutable copy
    copyBoard=board[:]

                
    
    #best squares in order
    BEST_SQUARES=(4,0,2,6,8,1,3,5,7)

    print("\nI shall take",)

    #if computer can win take it
    for move in legalMoves(board):
        board[move]=computer
        if winner(board)==computer:
            print(move)
            return move
        #done checking this move undo it
        board[move]=EMPTY

    #if human can win take it
    for move in legalMoves(board):
        board[move]=human
        if winner(board)==human:
            print(move)
            return move
        #done checking undo move
        board[move]=EMPTY

    #pick best move
    for move in BEST_SQUARES:
        if move in legalMoves(board):
            print(move)
            return move

def nextTurn(turn):
    """swithces turns"""
    if turn==X:
        return O
    else:
        return X
    
#finish congrat note
def congratWinner(theWinner,computer,human):
    """congrats to the winner"""
    if theWinner != TIE:
        print(theWinner,"won")
    else:
        print("It is a tie")

def main(parentNodes):
    displayInstruct()
    computer,human=pieces()
    turn=X
    board=newBoard()
    displayBoard(board)
    while not winner(board):
        if turn == human:
            move=humanMove(board)
            board[move]=human
            leafNodes, parentNodes=gameTree(board,parentNodes,computer,human,turn)
##          leafNodes, getParentNodes=gameTree(board,parentNodes,computer)
##          parentNodes=getParentNodes
##          printParentNodes=str(getParentNodes)
##          print("pn"+printParentNodes)

            data.write(str(move))
        else:
            move=computerMove(board,computer,human)
            board[move]=computer
            gameTree(board,parentNodes,computer,human,turn)
##          leafNodes, getParentNodes=gameTree(board,parentNodes,computer)
##          parentNodes=getParentNodes
##          printParentNodes=str(getParentNodes)
##          print("pn"+printParentNodes)

            data.write(str(move))
            
        displayBoard(board)
        turn=nextTurn(turn)
        
        #gather the data
        data.write(str(board)+"\n")
    data.write("\n")
    
    theWinner=winner(board)
    congratWinner(theWinner,computer,human)
main(parentNodes)
data.close()
    
            
    


    
    
        
        

    
        
    
    
        
    
    
        
			



        
    

    
    
        

    


    
    
