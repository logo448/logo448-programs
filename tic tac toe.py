#Logan Stenzel
#
#Tic Tac Toe

#global constants
X = "x"
O = "O"
TIE = "TIE"
EMPTY = " "
NUM_SQUARES = 9

#opening a file to write all the data to.
data = open("ticTacToeData", "a")


#functions
def display_instruct():
    """prints the directions to tic tac toe"""
    print """
    Welcome to Tic-Tac-Toe

    This will be the ultimate challenge my artificial intellegiance against
    your brain. To pick your square use the grid below.
    

                    0|1|2
                    -----
                    3|4|5
                    -----
                    6|7|8
                    

    Good luck because you don't stand a chance. To win you need to get
    three squares in a row."""


def ask_yes_no(question):
    """asks yes or no question"""
    response = None
    while response not in ("y", "n"):
        response = raw_input(question).lower()
    return response


def ask_number(question, low, high):
    """asks a number between two points"""
    response = None
    while response not in range(low, high):
        response = int(input(question))
    return response


def pieces():
    """determines who goes first"""
    go_first = ask_yes_no("Do you need the first move? (y/n): ")
    if go_first == "y":
        print "You will need it"
        human = X
        computer = O
    else:
        print "Your bravery will stab you in the butt..."
        computer = X
        human = O
    return computer, human


def new_board():
    """creates a new game board"""
    board = []
    for square in range(NUM_SQUARES):
        board.append(EMPTY)
    return board


def display_board(board):
    """Displays game board"""
    print
    print board[0], "|", board[1], "|", board[2]
    print "---------"
    print board[3], "|", board[4], "|", board[5]
    print "---------"
    print board[6], "|", board[7], "|", board[8]


def legal_moves(board):
    """checks if move is legal"""
    moves = []
    for square in range(NUM_SQUARES):
        if board[square] == EMPTY:
            moves.append(square)
    return moves


def winner(board):
    """checks for winner"""
    WAYS_TO_WIN = ((0, 1, 2),
            (3, 4, 5),
            (6, 7, 8),
            (0, 3, 6),
            (1, 4, 7),
            (2, 5, 8),
            (0, 4, 8),
            (2, 4, 6))
    for way in WAYS_TO_WIN:
        if board[way[0]] == board[way[1]] == board[way[2]] != EMPTY:
            winner = board[way[0]]
            return winner
    if EMPTY not in board:
        return TIE
    return None


def human_move(board):
    """gets human move"""
    legal = legal_moves(board)
    move = None
    while move not in legal:
        move = ask_number("Were will you go 0-8: ", 0, NUM_SQUARES)
        if move not in legal:
            print "That square is already taken, pick another one foolish human"
    return move


def computer_move(board, computer, human):
    """gets computers move"""
    #best squares in order
    BEST_SQUARES = (4, 0, 2, 6, 8, 1, 3, 5, 7)
    print "\nI shall take",
    #if computer can win take it
    for move in legal_moves(board):
        board[move] = computer
        if winner(board) == computer:
            print move
            return move
        #done checking this move undo it
        board[move] = EMPTY
    #if human can win take it
    for move in legal_moves(board):
        board[move] = human
        if winner(board) == human:
            print(move)
            return move
        #done checking undo move
        board[move] = EMPTY

    #pick best move
    for move in BEST_SQUARES:
        if move in legal_moves(board):
            print move
            return move


def next_turn(turn):
    """switches turns"""
    if turn == X:
        return O
    else:
        return X


#finish congrat note
def congrat_winner(the_winner):
    """congrats to the winner"""
    if the_winner != TIE:
        print the_winner, "won"
    else:
        print "It is a tie"


def main():
    display_instruct()
    computer, human = pieces()
    turn = X
    board = new_board()
    display_board(board)
    while not winner(board):
        if turn == human:
            move = human_move(board)
            board[move] = human
            data.write(str(move))
        else:
            move = computer_move(board, computer, human)
            board[move] = computer
            data.write(str(move))
        display_board(board)
        turn = next_turn(turn)
        #gather the data
        data.write(str(board)+"\n")
    data.write("\n")
    
    the_winner = winner(board)
    congrat_winner(the_winner)
main()
data.close()