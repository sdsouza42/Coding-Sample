static char Encode(char byte)
{
	if(byte == ' ') return byte;
	return byte ^ '#';
}

int ProcessBuffer(char bytes[], int count)
{
	register int i;

	for(i = 0; i < count; ++i)
		bytes[i] = Encode(bytes[i]);

	return count;
}
