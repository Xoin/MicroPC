# basic bios file to just print something

# What sub service do we want
store R0 1
#Where is the location we will point to
load R1 text
# Serivce
int 1
load R1 test
int 1
store R4 1
loop:
store R0 3
int 1
mov R3 R2
store R0 2
int 1
jnzero R4 loop
# Stop the program
halt
# Label to the data
text:
db "MicroLoader... $"
test:
db "Hi there Facepunch! This is a program loaded into RAM, and then loaded its text from RAM, with some magic it appears on the console.$"