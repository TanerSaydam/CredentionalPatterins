Computer computer = new();
CPU cpu = new CPU();
computer.CPU = cpu;

class Computer
{
    public CPU CPU { get; set; }
    public RAM RAM { get; set; }
    public VideoCard VideoCard { get; set; }
}

class CPU
{

}

class RAM
{

}

class VideoCard
{

}