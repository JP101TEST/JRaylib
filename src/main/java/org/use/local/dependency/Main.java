package org.use.local.dependency;


import lombok.Data;
import lombok.extern.log4j.Log4j2;
import org.use.local.dependency.core.Game;


public class Main {
    public static void main(String[] args) {
        Game game = new Game();
        game.run();
    }

}