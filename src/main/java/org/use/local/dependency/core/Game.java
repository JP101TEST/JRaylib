package org.use.local.dependency.core;

import lombok.extern.log4j.Log4j2;

import static com.raylib.Raylib.*;

@Log4j2
public class Game {
    public void run() {
        log.info("Game start");
        init();
        loop();
        closeWindow();
    }

    private void init() {
        initWindow(800, 450, "Demo");
        setWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        setTargetFPS(60);
    }

    private void loop() {
        while (!windowShouldClose()) {
            beginDrawing();
            clearBackground(BLACK);

            drawText("X : " + getMousePosition().x() + "|| Y : " + getMousePosition().y(), 0, 160, 1, YELLOW);

            drawText("W : " + getScreenWidth() + "|| H : " + getScreenHeight(), 0, 200, 1, VIOLET);

            drawFPS(0, 0);
            endDrawing();
        }
    }


}
