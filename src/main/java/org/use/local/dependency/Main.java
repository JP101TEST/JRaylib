package org.use.local.dependency;


import lombok.Data;
import lombok.extern.log4j.Log4j2;

@Log4j2
public class Main {
    public static void main(String[] args) {
        log.info("Hello, World!");
        System.out.println("Hello, World!");

        Person person = new Person();
        person.setName("John");
        person.setAge(30);
        log.info("Name: {}, Age: {}", person.getName(), person.getAge());
    }

    @Data
    static class Person {
        private String name;
        private int age;
    }
}