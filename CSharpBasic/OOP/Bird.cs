﻿namespace OOP
{
    /*
     * 추상클래스 (abstract class)
     * 추상적인 멤버들을 선언하기위한 클래스. 추상적인 개념이기때문에 인스턴스화가 안됨.
     * 
     * 추상클래스 vs 인터페이스
     * 
     * 추상클래스 : 데이터 및 기능들을 캡슐화하면서 단일상속 및 다형성을 제공하기위한 추상적인 사용자정의자료형
     * 인터페이스 : 외부에서 상호작용할 목적의 기능 목록을 공개하기위한 사용자정의자료형.
     */
    internal abstract class Bird
    {
        /*
         * Class 는 멤버를 캡슐화하는것이 기본 컨셉이기때문에,
         * 접근제한자가 명시되지 않으면 private으로 기본 설정됨.
         */
        string _beak; // 부리
        private string _wing; // 날개
    }
}
