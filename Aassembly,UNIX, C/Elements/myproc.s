.intel_syntax noprefix

.text

#####################################################
# Procedure to calculate GCD of two positive integers
# Argument: first=EAX, second=ECX
# Result: EAX
#####################################################

_GCD:
1:	cmp	eax, ecx
	je	3f

	ja	2f

	sub	ecx, eax
	jmp	1b

2:	sub	eax, ecx
	jmp	1b

3:	ret

.global	_GCD	#public procedure - can be called from other modules

.end

