# Avalonia Web Control Collection
[go](https://delightful-profiterole-0fa25d.netlify.app/)
## 프로젝트 소개
이 저장소는 Avalonia에서 웹을 통해 UI를 구동할 수 있는지 테스트하는 과정에서 시작되었습니다. 처음에는 블로그 형태로 접근하려 했으나, Avalonia의 다양한 컨트롤을 보다 효과적으로 보여줄 방법을 고민하게 되었습니다. 그래서 제 Avalonia 컨트롤 소스들을 모아 하나의 컬렉션으로 정리하는 방향으로 전환하게 되었습니다.

## 진행 과정
처음에는 소스를 직접 저장소에 추가하는 방법을 고려했으나, 불필요한 중복 작업이라 생각되어 git submodule을 사용하여 소스를 가져왔습니다. 하나씩 연동해가며 프로젝트를 완성해 나가고 있습니다.

## 호스팅
처음엔 GitHub Pages를 통해 웹 호스팅을 진행했지만, 샘플 소스를 3개 이상 등록하자 .wasm 파일로 인해 git push 용량 제한 문제가 발생했습니다. 이를 해결하기 위해 무료 호스팅 서비스인 Netlify를 사용하여 문제를 극복했습니다.

## 앞으로의 계획
앞으로도 개인적으로 Avalonia 컨트롤을 추가할 계획이니, 관심 있게 지켜봐 주세요!

### Git clone
```
git clone --recurse-submodules https://github.com/lukewire129/lukewireBlogAvalonia.git
```
