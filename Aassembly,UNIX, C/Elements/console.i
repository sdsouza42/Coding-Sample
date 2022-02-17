####################################################################
# Name          : console.i
# Description   : Defines macros for calling input/output procedures
#                 implemented in system.o
# Author        : K.M.Hussain
# Licence       : Educational
####################################################################



.extern WriteS, WriteSZ, WriteLF, ReadS, WriteI, ReadI

# PutStr - Outputs a string with address in value and size in len.
.macro  PutStr  value, len
    mov     %edx, \value
    mov     %ecx, \len
    call    WriteS
.endm

# Prompt - Outputs a null terminated string identified by label in value.
.macro  Prompt  value
    mov     %edx, offset \value
    call    WriteSZ
.endm

# PutEOL - Outputs an end-of-line character
.macro  PutEOL
    call    WriteLF
.endm

# GetStr - Inputs a string in buffer with address in value and size in len.
.macro  GetStr  value, len
    mov     %edx, \value
    mov     %ecx, \len
    call    ReadS
.endm

# PutInt - Outputs a 32-bit decimal integer value.
.macro  PutInt  value
    mov     %eax, \value
    call    WriteI
.endm

# GetInt - Inputs a 32-bit decimal integer into value 
# and clears or sets ZF if successful or failed.
.macro  GetInt  value
    call    ReadI
    mov     \value, %eax
.endm

