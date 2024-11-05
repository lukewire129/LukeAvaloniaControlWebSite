# Avalonia Web Control Collection Web

[Go](https://delightful-profiterole-0fa25d.netlify.app/)
## Project Overview
This repository started as a test to see how well Avalonia could run a UI through the web. Initially, I considered approaching it as a blog, but I wanted a more effective way to showcase Avalonia's various controls. That led me to collect and organize my Avalonia control sources into a single collection.

## Progress
At first, I thought about adding the source code directly to the repository, but I realized it would lead to unnecessary duplication. So, I used git submodule to bring in the source code and have been integrating everything step by step to complete the project.

## Hosting
Initially, I hosted the project through GitHub Pages, but after adding more than three sample sources, I encountered a git push size limit due to the .wasm files. To overcome this, I switched to the free hosting service, Netlify, which solved the issue.

## Future Plans
I plan to continue adding more Avalonia controls in the future, so please stay tuned!

### Git clone
```
git clone --recurse-submodules https://github.com/lukewire129/lukewireBlogAvalonia.git
```
