## .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
```assembly
; MinimalBenchmark.LoopBenchmarks.For()
       sub       rsp,28
       xor       eax,eax
       xor       ecx,ecx
       mov       rdx,1C7C4801DF8
       mov       rdx,[rdx]
       mov       r8d,[rdx+10]
       test      r8d,r8d
       jle       short M00_L01
M00_L00:
       mov       r10,rdx
       cmp       ecx,r8d
       jae       short M00_L02
       mov       r10,[r10+8]
       cmp       ecx,[r10+8]
       jae       short M00_L03
       mov       r9d,ecx
       add       eax,[r10+r9*4+10]
       inc       ecx
       cmp       ecx,r8d
       jl        short M00_L00
M00_L01:
       add       rsp,28
       ret
M00_L02:
       call      qword ptr [7FF9796CEA30]
       int       3
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 81
```

## .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
```assembly
; MinimalBenchmark.LoopBenchmarks.Foreach()
       sub       rsp,28
       xor       eax,eax
       mov       rcx,1F6C9C01DF8
       mov       rcx,[rcx]
       xor       edx,edx
       jmp       short M00_L01
M00_L00:
       add       eax,r8d
M00_L01:
       mov       r8d,[rcx+10]
       cmp       edx,r8d
       jae       short M00_L02
       mov       r8,[rcx+8]
       cmp       edx,[r8+8]
       jae       short M00_L03
       mov       r10d,edx
       mov       r8d,[r8+r10*4+10]
       inc       edx
       jmp       short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 68
```

## .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
```assembly
; MinimalBenchmark.LoopBenchmarks.While()
       sub       rsp,28
       xor       eax,eax
       xor       ecx,ecx
       mov       rdx,21CEC801DF8
       mov       rdx,[rdx]
       mov       r8d,[rdx+10]
       test      r8d,r8d
       jle       short M00_L01
M00_L00:
       mov       r10,rdx
       cmp       ecx,r8d
       jae       short M00_L02
       mov       r10,[r10+8]
       cmp       ecx,[r10+8]
       jae       short M00_L03
       mov       r9d,ecx
       add       eax,[r10+r9*4+10]
       inc       ecx
       cmp       ecx,r8d
       jl        short M00_L00
M00_L01:
       add       rsp,28
       ret
M00_L02:
       call      qword ptr [7FF9796CEA30]
       int       3
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 81
```

