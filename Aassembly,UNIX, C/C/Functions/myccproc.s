.intel_syntax noprefix

.text

_GCD:	#legacy
1:	cmp	eax, ecx
	je	3f

	ja	2f

	sub	ecx, eax
	jmp	1b

2:	sub	eax, ecx
	jmp	1b

3:	ret

GCD:
	mov	eax, [esp+4]
	mov	ecx, [esp+8]
	jmp	_GCD		#thunking

.global	GCD
.type	GCD, @function

GCDN:
	push	ebp
	mov	ebp, esp

	mov	edx, 8
	mov	eax, [ebp+8]
1:	add	edx, 4
	mov	ecx, [ebp+edx]
	cmp	ecx, 0
	je	2f
	call	_GCD
	jmp	1b
	
2:	mov	esp, ebp
	pop	ebp
	ret

.global	GCDN
.type	GCDN @function

.end

