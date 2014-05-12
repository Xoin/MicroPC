###############################################################################
# a simple test program to compare a input string to one in memory then       #
# excutes a small program already in memory lables are a easy way to mark     #
# where a programs ends we can assume we can write there freely should be the #
#  default to run programs later on.                                          #
###############################################################################

###############################################################################
# Welcome message                                                             #
###############################################################################

store R0 1
load R1 welcome
int 1
store R0 5
int 1

###############################################################################
#Things we need before starting                                               #
###############################################################################

:start
load R1 command_line
store R0 1
int 1
store R5 1
store R4 36
load R3 end

###############################################################################
# Main Loop                                                                   #
#    System     end    term   loop                                            #
# [ R0 R1 R2 ] [ R3 ] [ R4 ] [ R5 ]                                           #
#                                                                             #
###############################################################################

:loop
# Write input to R1
store R0 3
int 1
# Write char to console from R1
store R0 2
int 1
#find out where the free ram is and write to it
write R1 R3
inc R3
# is it the end of the string?
cmp R1 R4 R0
jnzero R0 compare
jnzero R5 loop

###############################################################################
# Compare some shit                                                           #
#    System                                                                   #
# [ R0 R1 R2 R3 ] R4  R5                                                      #
#                                                                             #
###############################################################################

compare:
# lets clear that
store R3 0
#the command we want (lets pretend you have a choice)
load R1 command_ver
# hey there now to so free RAM!
load R2 end
#lets compare
store R0 4
int 1
jnzero R3 ver

store R3 0
#the command we want (lets pretend you have a choice)
load R1 command_facepunch
# hey there now to so free RAM!
load R2 end
#lets compare
store R0 4
int 1
jnzero R3 facepunch_p
store R0 5
int 1
jump start

###############################################################################
# Internal programs                                                           #
###############################################################################

#version program
:ver
store R0 5
int 1
store R0 1
load R1 version
int 1
store R0 5
int 1
jump clean

#facepunch program
:facepunch_p
store R0 5
int 1
store R0 1
load R1 facepunch
int 1
store R0 5
int 1
jump clean

# Clean make sure everything is as we started 
:clean
load R3 clear
:cleansub
load R0 end
store R1 0
write R1 R0
inc R0
cmp R0 R3 R2
jnzero R2 cleansub
store R0 0
store R1 0
store R2 0
store R3 0
store R4 0
store R5 0
jump start

###############################################################################
# Strings to use                                                              #
###############################################################################
:welcome
db "Welcome to MicroDOS$"
:command_line
db "> $"
:version
db "MicroDOS Version 0.0.1$"
:facepunch
db "Hi there Facepunch$"
:command_facepunch
db "FACEPUNCH$"
:command_ver
db "VER$"
:end
db "FILLFILLFILLFILL$"
:clear