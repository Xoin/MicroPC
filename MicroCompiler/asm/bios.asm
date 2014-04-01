# basic bios file to just print something

# What sub service do we want
store R0 1
#Where is the location we will point to
load R1 text
# Serivce
int 1
#load location of test to register
load R1 test
# service
int 1
#store 1 to R4
store R4 1
#loop here
loop:
# store 3 to R0 (read keyboard input)
store R0 3
#call service
int 1
# copy content to R3 to # r2
mov R3 R2
# store 2 in R0
store R0 2
#call service
int 1
# jump to loop if R4 still is zero
jnzero R4 loop
# Stop the program
halt
# Label to the data
text:
db "MicroLoader... $"
#mark end of program (so we know where our program ends and where its safe to use)
test: