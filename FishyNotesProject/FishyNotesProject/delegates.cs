﻿using System;

namespace FishyNotesProject
{
    public delegate void RemoveNoteDelegate(int id);

    public delegate void ReturnVoidDelegate();

    public delegate void ReturnVoidCommand();

    public delegate void StringVoidDelegate(String data);
}
